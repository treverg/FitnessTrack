using Database;
using Microsoft.AspNetCore.Components;
using Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTrack.Pages
{
    public partial class MainTracker : ComponentBase
    {
        [Inject]
        DataReader DataReader { get; set; }

        private int repetitionCount = 0;

        private int setCount = 0;

        private bool disableCustomRepitionCount = true;

        private bool disableCustomSetCount = true;

        public List<Exercise> Exercises = new List<Exercise>();

        private void EnableCustomRepetitionCount(int repCount)
        {
            this.repetitionCount = repCount;
            disableCustomRepitionCount = false;
        }

        private void DisableCustomRepetitionCount(int repCount)
        {
            this.repetitionCount = repCount;
            disableCustomRepitionCount = true;
        }

        private void EnableCustomSetCount(int setCount)
        {
            this.setCount = setCount;
            this.disableCustomSetCount = false;
            this.AddSetsToExercise();
        }

        private void DisableCustomSetCount(int setCount)
        {
            this.setCount = setCount;
            this.disableCustomSetCount = true;
            this.AddSetsToExercise();
        }

        private void AddSetsToExercise()
        {
            foreach (var exercise in Exercises)
            {
                exercise.SetInformation.Clear();
                for (int i = 0; i < setCount; i++)
                {
                    exercise.SetInformation.Add(new SetInformation());
                }
            }
        }

        private void DecrementRepCount(SetInformation setInformation)
        {
            setInformation.RepCount = setInformation.RepCount == 0 ? this.repetitionCount : setInformation.RepCount - 1;
        }

        protected override async Task OnInitializedAsync()
        {
            this.Exercises = (await DataReader.GetExercises()).ToList();
        }
    }
}
