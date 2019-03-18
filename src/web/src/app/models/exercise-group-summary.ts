import { IExerciseGroup } from './exercise-group';
import { ITimeSpanWrapper } from './time-span-wrapper';

export interface IExerciseGroupSummary extends IExerciseGroup {    
    canDelete: boolean,
    totalTimeDieting: ITimeSpanWrapper,
    weightLostThisWeek: number,
    weightLostInTotal: number,
    weightLosingPerWeek: number,
    totalExerciseDistance: number,
    totalTimeSpentExercising: ITimeSpanWrapper,
    exerciseCount: number
}