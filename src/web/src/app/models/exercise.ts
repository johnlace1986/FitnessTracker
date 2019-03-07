import { ITimeSpanWrapper } from './time-span-wrapper';

export interface IExercise {
    id: string,
    recorded: Date,
    timeTaken: ITimeSpanWrapper,
    distance: number,
    caloriesBurned: number
}