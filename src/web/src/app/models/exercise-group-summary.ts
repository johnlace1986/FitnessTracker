import { IExerciseGroup } from './exercise-group';

export interface IExerciseGroupSummary extends IExerciseGroup {    
    canDelete: boolean,
    startDate: Date,
    exerciseCount: number,
    isExpanded: boolean
}