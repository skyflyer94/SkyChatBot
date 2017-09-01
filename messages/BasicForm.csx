using System;
using Microsoft.Bot.Builder.FormFlow;

public enum CarOptions { Convertible = 1, SUV, EV };
public enum ColorOptions { Red = 1, White, Blue, Green, Purple};
public enum GenderOptions { Male = 1, Female };

public enum PizzaOptions { Fish=1, Chicken, Beef, Hawaii };

// For more information about this template visit http://aka.ms/azurebots-csharp-form
[Serializable]
public class BasicForm
{
    [Prompt("Hi! What is your {&}?")]
    public string Name { get; set; }

    [Prompt("Please select your favorite car type {||}")]
    public CarOptions Car { get; set; }

    [Prompt("Please select your favorite {&} {||}")]
    public ColorOptions Color { get; set; }

    public static IForm<BasicForm> BuildForm()
    {
        // Builds an IForm<T> based on BasicForm
        return new FormBuilder<BasicForm>().Build();
    }

    public static IFormDialog<SecondForm> BuildFormDialog(FormOptions options = FormOptions.PromptInStart)
    {
        // Generated a new FormDialog<T> based on IForm<BasicForm>
        return FormDialog.FromForm(BuildForm, options);
    }
}

[Serializable]
public class SecondForm
{
    [Prompt("2nd Times~~ Hi! What is your {&}?")]
    public GenderOptions Gender { get; set; }

    [Prompt("Please select your favorite {&} {||}")]
    public PizzaOptions Pizza { get; set; }
}