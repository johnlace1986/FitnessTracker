import { IExerciseGroupSummary } from './exercise-group-summary';

export interface IExerciseGroupPeriod {
    title: string,
    year: number,
    month: number,
    totalWeightLost: number,
    summaries: Array<IExerciseGroupSummary>,
    isExpanded: boolean
}