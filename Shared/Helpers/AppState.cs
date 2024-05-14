using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Helpers;

public class AppState
{
    public bool IsBusy { get; set; }
    public bool IsProcessing { get; set; }

    public string? SearchString { get; set; }

    public event EventHandler? UpdateQuestionsHandler;

    public void UpdateQuestions() => UpdateQuestionsHandler?.Invoke(this, EventArgs.Empty);

    public event EventHandler<string>? ChoiceHandler;
    public void UpdateChoice(string choice) => ChoiceHandler?.Invoke(this, choice);

    public event EventHandler<List<string>>? ChoicesHandler;
    public void UpdateChoices(List<string> choices) => ChoicesHandler?.Invoke(this, choices);
}
