import { IExerciseGroupSummary } from './exercise-group-summary';

export interface IExerciseGroupPeriod {
    year: number,
    month: number,
    groups: Array<IExerciseGroupSummary>
}