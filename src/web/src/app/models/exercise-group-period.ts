import { IExerciseGroupSummary } from './exercise-group-summary';

export interface IExerciseGroupPeriod {
    year: number,
    month: string,
    groups: Array<IExerciseGroupSummary>
}