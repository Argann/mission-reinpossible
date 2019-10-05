using UnityEditor;
using UnityEngine;
using System.Linq;

public class LevelEditorWindow : EditorWindow 
{
    private Vector2 generalScroll;

    /// <summary>
    /// Méthode lancée à l'activation de l'éditeur
    /// </summary>
    void OnEnable() 
    {
        titleContent.text = "Mission Rein-Possible - Level Editor";
    }

    /// <summary>
    /// Méthode appelée lorsque l'utilisateur souhaite afficher la 
    /// fenêtre.
    /// </summary>
    [MenuItem("Game Design/Level Editor")]
    public static void ShowWindow() 
    {
        EditorWindow ew = EditorWindow.GetWindow(typeof(LevelEditorWindow));
        ew.minSize = new Vector2(500, 500);
    }

    void Update()
    {
        Repaint();
    }

    /// <summary>
    /// Méthode appelée à chaque frame de rendu de l'UI
    /// </summary>
    void OnGUI() 
    {

        DrawMainMenu();

        DrawLevelEditorMenu();

        DrawFooter();

    }

    /// <summary>
    /// Méthode permettant d'afficher le menu principal de l'éditeur.
    /// </summary>
    void DrawMainMenu() 
    {
        Space();

        Label("Mission Rein-Possible - Level Editor", 20, FontStyle.Italic);        

        Space();

        generalScroll = GUILayout.BeginScrollView(generalScroll);
    }

    /// <summary>
    /// Méthode permettant l'affichage du menu d'ennemis
    /// </summary>
    void DrawLevelEditorMenu() {

        Label("Levels", 15);

        // TODO

    }

    /// <summary>
    /// Méthode permettant d'afficher le footer de la fenêtre.
    /// </summary>
    void DrawFooter() {
        GUILayout.EndScrollView();
    }

    /// <summary>
    /// Alias pour EditorGUILayout.Space()
    /// </summary>
    void Space() {
        EditorGUILayout.Space();
    }

    /// <summary>
    /// Méthode permettant d'afficher un Label
    /// ayant un style particulier
    /// </summary>
    void Label(string text, int fontSize = 12, FontStyle fontStyle = FontStyle.Normal, int fixedWidth = 0) {
        int baseLabelFontSize = GUI.skin.label.fontSize;

        GUI.skin.label.fontSize = fontSize;
        GUI.skin.label.fontStyle = fontStyle;

        if (fixedWidth == 0) {
            GUILayout.Label(text);
        } else {
            GUILayout.Label(text, GUILayout.Width(fixedWidth));
        }

        GUI.skin.label.fontSize = baseLabelFontSize;
        GUI.skin.label.fontStyle = FontStyle.Normal;
    }
}