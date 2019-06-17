import { IExerciseGroup } from './exercise-group';

export interface IExerciseGroupSummary extends IExerciseGroup {    
    canDelete: boolean,
    exerciseCount: number,
    isExpanded: boolean
}