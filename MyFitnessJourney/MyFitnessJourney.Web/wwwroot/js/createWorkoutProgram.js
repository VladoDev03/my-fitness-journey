(function () {
    const maxDays = 7;
    let dayIndex = 1;

    const exercisesDataDiv = document.getElementById('exercisesData');
    const exercises = JSON.parse(exercisesDataDiv.dataset.exercises);

    const daysContainer = document.getElementById('daysContainer');
    const addDayBtn = document.getElementById('addDayBtn');

    function updateExerciseIds() {
        const selects = document.querySelectorAll('.exerciseSelect');
        selects.forEach(select => {
            const selectedOption = select.options[select.selectedIndex];
            const exerciseIdInput = select.closest('.exercise-row').querySelector('.exerciseIdInput');
            exerciseIdInput.value = selectedOption?.dataset.id || '';
        });
    }

    function addExercise(dayBlock, dayIdx) {
        const exercisesContainer = dayBlock.querySelector('.exercisesContainer');
        const exerciseCount = exercisesContainer.querySelectorAll('.exercise-row').length;

        const div = document.createElement('div');
        div.classList.add('exercise-row');

        const select = document.createElement('select');
        select.classList.add('exerciseSelect');
        select.name = `Program.Days[${dayIdx}].Exercises[${exerciseCount}].Name`;
        select.required = true;

        const defaultOption = document.createElement('option');
        defaultOption.value = "";
        defaultOption.text = "-- Select Exercise --";
        select.appendChild(defaultOption);

        exercises.forEach(ex => {
            const option = document.createElement('option');
            option.value = ex.name;
            option.text = ex.name;
            option.dataset.id = ex.id;
            select.appendChild(option);
        });

        const exerciseIdInput = document.createElement('input');
        exerciseIdInput.type = 'hidden';
        exerciseIdInput.name = `Program.Days[${dayIdx}].Exercises[${exerciseCount}].ExerciseId`;
        exerciseIdInput.classList.add('exerciseIdInput');
        exerciseIdInput.value = "";

        const setsInput = document.createElement('input');
        setsInput.type = 'number';
        setsInput.name = `Program.Days[${dayIdx}].Exercises[${exerciseCount}].Sets`;
        setsInput.min = 1;
        setsInput.placeholder = 'Sets';
        setsInput.required = true;

        const repsMinInput = document.createElement('input');
        repsMinInput.type = 'number';
        repsMinInput.name = `Program.Days[${dayIdx}].Exercises[${exerciseCount}].RepsMin`;
        repsMinInput.min = 1;
        repsMinInput.placeholder = 'Min Reps';
        repsMinInput.required = true;

        const repsMaxInput = document.createElement('input');
        repsMaxInput.type = 'number';
        repsMaxInput.name = `Program.Days[${dayIdx}].Exercises[${exerciseCount}].RepsMax`;
        repsMaxInput.min = 1;
        repsMaxInput.placeholder = 'Max Reps';
        repsMaxInput.required = true;

        const removeExerciseBtn = document.createElement('button');
        removeExerciseBtn.type = 'button';
        removeExerciseBtn.classList.add('removeExerciseBtn');
        removeExerciseBtn.textContent = 'Remove Exercise';
        removeExerciseBtn.addEventListener('click', () => div.remove());

        select.addEventListener('change', updateExerciseIds);

        div.appendChild(select);
        div.appendChild(exerciseIdInput);
        div.appendChild(setsInput);
        div.appendChild(repsMinInput);
        div.appendChild(repsMaxInput);
        div.appendChild(removeExerciseBtn);

        [setsInput, repsMinInput, repsMaxInput].forEach(input => {
            input.style.width = '75px';
        });

        exercisesContainer.appendChild(div);
    }

    addDayBtn.addEventListener('click', () => {
        if (dayIndex >= maxDays) {
            alert(`Максимум ${maxDays} дни са позволени.`);
            return;
        }

        const dayBlock = document.createElement('div');
        dayBlock.classList.add('day-block');
        dayBlock.dataset.dayIndex = dayIndex;

        const h3 = document.createElement('h3');
        h3.textContent = `Day ${dayIndex + 1}`;

        const dayNameInput = document.createElement('input');
        dayNameInput.type = 'hidden';
        dayNameInput.name = `Program.Days[${dayIndex}].DayName`;
        dayNameInput.value = `Day ${dayIndex + 1}`;

        const exercisesContainer = document.createElement('div');
        exercisesContainer.classList.add('exercisesContainer');

        dayBlock.appendChild(h3);
        dayBlock.appendChild(dayNameInput);
        dayBlock.appendChild(exercisesContainer);

        addExercise(dayBlock, dayIndex);

        const addExerciseBtn = document.createElement('button');
        addExerciseBtn.type = 'button';
        addExerciseBtn.classList.add('addExerciseBtn');
        addExerciseBtn.textContent = 'Add Exercise';
        addExerciseBtn.addEventListener('click', () => addExercise(dayBlock, dayIndex));

        const removeDayBtn = document.createElement('button');
        removeDayBtn.type = 'button';
        removeDayBtn.classList.add('removeDayBtn');
        removeDayBtn.textContent = 'Remove Day';
        removeDayBtn.addEventListener('click', () => {
            dayBlock.remove();
            updateAllDayIndices();
            dayIndex--;
        });

        dayBlock.appendChild(addExerciseBtn);
        dayBlock.appendChild(removeDayBtn);

        daysContainer.appendChild(dayBlock);

        dayIndex++;
    });

    document.querySelectorAll('.removeExerciseBtn').forEach(btn => {
        btn.addEventListener('click', e => {
            e.target.closest('.exercise-row').remove();
        });
    });

    document.querySelectorAll('.addExerciseBtn').forEach(btn => {
        btn.addEventListener('click', e => {
            const dayBlock = e.target.closest('.day-block');
            const dayIdx = parseInt(dayBlock.dataset.dayIndex);
            addExercise(dayBlock, dayIdx);
        });
    });

    document.querySelectorAll('.removeDayBtn').forEach(btn => {
        btn.addEventListener('click', e => {
            e.target.closest('.day-block').remove();
            updateAllDayIndices();
            dayIndex--;
        });
    });

    function updateAllDayIndices() {
        const dayBlocks = document.querySelectorAll('.day-block');
        dayBlocks.forEach((dayBlock, index) => {
            dayBlock.dataset.dayIndex = index;
            dayBlock.querySelector('h3').textContent = `Day ${index + 1}`;
            dayBlock.querySelector('input[type="hidden"][name*="DayName"]').name = `Program.Days[${index}].DayName`;
            dayBlock.querySelector('input[type="hidden"][name*="DayName"]').value = `Day ${index + 1}`;

            const exercises = dayBlock.querySelectorAll('.exercise-row');
            exercises.forEach((exerciseRow, eIdx) => {
                const select = exerciseRow.querySelector('select.exerciseSelect');
                select.name = `Program.Days[${index}].Exercises[${eIdx}].Name`;

                const exerciseIdInput = exerciseRow.querySelector('input.exerciseIdInput[type="hidden"]');
                exerciseIdInput.name = `Program.Days[${index}].Exercises[${eIdx}].ExerciseId`;

                const setsInput = exerciseRow.querySelector('input[name*="Sets"]');
                setsInput.name = `Program.Days[${index}].Exercises[${eIdx}].Sets`;

                const repsMinInput = exerciseRow.querySelector('input[name*="RepsMin"]');
                repsMinInput.name = `Program.Days[${index}].Exercises[${eIdx}].RepsMin`;

                const repsMaxInput = exerciseRow.querySelector('input[name*="RepsMax"]');
                repsMaxInput.name = `Program.Days[${index}].Exercises[${eIdx}].RepsMax`;
            });
        });
    }

    document.querySelectorAll('.exerciseSelect').forEach(select => {
        select.addEventListener('change', updateExerciseIds);
    });

    updateExerciseIds();
})();
