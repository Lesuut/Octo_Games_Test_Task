using Naninovel;
using UnityEngine;

[CommandAlias("miniGame")]
public class MiniGameCommand : Command
{
    [ParameterAlias("skript")]
    public StringParameter Skript;

    [SerializeField] private PlayScript _playScript;

    public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        var skripts = Engine.GetService<IScriptPlayer>();
        skripts.Play(Script.FromScriptText("a", "@hideAll"));

        var spawnManager = Engine.GetService<IUIManager>();

        spawnManager.AddModalUI(spawnManager.GetUI("MiniGame"));

        return UniTask.CompletedTask;
    }
}
