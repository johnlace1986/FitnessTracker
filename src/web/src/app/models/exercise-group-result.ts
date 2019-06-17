import { IExerciseGroup } from './exercise-group';
import { IExercise } from './exercise';

export interface IExerciseGroupResult extends IExerciseGroup {    
    canDelete: boolean,
    exercises: Array<IExercise>
}