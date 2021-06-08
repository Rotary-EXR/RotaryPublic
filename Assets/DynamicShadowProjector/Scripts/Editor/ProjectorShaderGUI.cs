﻿//
// ProjectorShaderGUI.cs
//
// Dynamic Shadow Projector
//
// Copyright 2019 NYAHOON GAMES PTE. LTD. All Rights Reserved.
//

using UnityEngine;
using UnityEditor;

namespace DynamicShadowProjector {
	public class ProjectorShaderGUI : ShaderGUI
#if UNITY_2019_4_OR_NEWER && !UNITY_2020_3_OR_NEWER
		, UnityEditor.Build.IPostprocessBuildWithReport
#endif
	{
		private enum ProjectorType {
			UnityProjector,
			CustomProjector
		}
		static private string ProjectorTypeToKeyword(ProjectorType type)
		{
			switch (type) {
			case ProjectorType.CustomProjector:
				return "FSR_RECEIVER";
			case ProjectorType.UnityProjector:
				return "";
			}
			return null;
		}
#if UNITY_2019_4_OR_NEWER && !UNITY_2020_3_OR_NEWER
		private static int GetUnityMinorVersionNumber(string minorVersionString)
		{
			int minorVersion = 0;
			for (int i = 0; i < minorVersionString.Length; ++i)
			{
				char v = minorVersionString[i];
				if ('0' <= v && v <= '9')
				{
					minorVersion = 10 * minorVersion + v - '0';
				}
				else
				{
					break;
				}
			}
			return minorVersion;
		}
		private GUIStyle m_textStyle = null;
		protected GUIStyle textStyle
		{
			get
			{
				if (m_textStyle == null)
				{
					m_textStyle = new GUIStyle();
					m_textStyle.richText = true;
					m_textStyle.wordWrap = true;
				}
				return m_textStyle;
			}
		}
		private static readonly string DYNAMIC_SHADER_NOT_SUPPORTED = "'DynamicShadowProjector/Projector/Dynamic/' shaders may not work in an application built with the following versions of Unity. Please upgrade Unity Editor." + System.Environment.NewLine
			+ "    Unity 2019.4.6 - 2019.4.19," + System.Environment.NewLine
			+ "    Unity 2020.1.0 - 2020.2.2" ;
		private static bool IsDynamicProjectorShaderSupported()
		{
			bool supported = true;
			string unityVersion = Application.unityVersion;
			string[] versionNumbers = unityVersion.Split('.');
			Debug.Assert(versionNumbers.Length == 3);
			Debug.Assert(versionNumbers[0] == "2019" || versionNumbers[0] == "2020");
			if (versionNumbers[0] == "2019")
			{
				Debug.Assert(versionNumbers[1] == "4");
				int minorVersion = GetUnityMinorVersionNumber(versionNumbers[2]);
				if (6 <= minorVersion && minorVersion < 20)
				{
					supported = false;
				}
			}
			else if (versionNumbers[0] == "2020")
			{
				Debug.Assert(versionNumbers[1] == "1" || versionNumbers[1] == "2");
				if (versionNumbers[1] == "2")
				{
					int minorVersion = GetUnityMinorVersionNumber(versionNumbers[2]);
					if (minorVersion < 3)
					{
						supported = false;
					}
				}
				else
				{
					supported = false;
				}
			}
			return supported;
		}
#endif
		public override void OnGUI (MaterialEditor materialEditor, MaterialProperty[] properties)
		{
			base.OnGUI (materialEditor, properties);
			Material material = materialEditor.target as Material;
			ProjectorType currentType = ProjectorType.UnityProjector;
			if (material.IsKeywordEnabled ("FSR_RECEIVER")) {
				currentType = ProjectorType.CustomProjector;
			}
			float oldLabelWidth = EditorGUIUtility.labelWidth;
			EditorGUIUtility.labelWidth = 150;
			ProjectorType newType = (ProjectorType)EditorGUILayout.EnumPopup("Projector Type", currentType);
			EditorGUIUtility.labelWidth = oldLabelWidth;
			if (newType != currentType) {
				Undo.RecordObject (material, "Change Projector Type");
				string keyword = ProjectorTypeToKeyword (currentType);
				if (!string.IsNullOrEmpty (keyword)) {
					material.DisableKeyword (keyword);
				}
				keyword = ProjectorTypeToKeyword (newType);
				if (!string.IsNullOrEmpty (keyword)) {
					material.EnableKeyword (keyword);
				}
			}
			bool forLWRP = material.IsKeywordEnabled("FSR_PROJECTOR_FOR_LWRP");
#if UNITY_2019_3_OR_NEWER
			bool newLWRP = EditorGUILayout.Toggle("Build for Universal RP", forLWRP);
#else
			bool newLWRP = EditorGUILayout.Toggle("Build for LWRP", forLWRP);
#endif
			if (newLWRP != forLWRP)
			{
				Undo.RecordObject(material, "Change Target Renderpipeline");
				if (newLWRP)
				{
					material.EnableKeyword("FSR_PROJECTOR_FOR_LWRP");
				}
				else
				{
					material.DisableKeyword("FSR_PROJECTOR_FOR_LWRP");
				}
			}
#if UNITY_2019_4_OR_NEWER && !UNITY_2020_3_OR_NEWER
			if (material.shader != null && material.shader.name.StartsWith("DynamicShadowProjector/Projector/Dynamic/") && !IsDynamicProjectorShaderSupported())
			{
				GUILayout.TextArea("<color=red>" + DYNAMIC_SHADER_NOT_SUPPORTED + "</color>", textStyle);
			}
#endif
		}
#if UNITY_2019_4_OR_NEWER && !UNITY_2020_3_OR_NEWER
		public int callbackOrder => 0;

		public void OnPostprocessBuild(UnityEditor.Build.Reporting.BuildReport report)
		{
			if (!IsDynamicProjectorShaderSupported())
			{
				var packedAssets = report.packedAssets;
				foreach (var pack in packedAssets)
				{
					foreach (var assetInfo in pack.contents)
					{
						if (assetInfo.type == typeof(Shader) && assetInfo.sourceAssetPath.Contains("Projector/Dynamic"))
						{
							Shader shader = AssetDatabase.LoadAssetAtPath<Shader>(assetInfo.sourceAssetPath);
							if (shader.name.StartsWith("DynamicShadowProjector/Projector/Dynamic/"))
							{
								Debug.LogError(DYNAMIC_SHADER_NOT_SUPPORTED, shader);
								return;
							}
						}
					}
				}
			}
		}
#endif
	}
}
