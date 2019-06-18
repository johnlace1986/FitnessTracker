import { Pipe, PipeTransform } from '@angular/core';
import { TimeDifferenceDisplayFormat } from 'src/app/models/time-difference-display-format';

@Pipe({
  name: 'timeDifference'
})
export class TimeDifferencePipe implements PipeTransform {

  transform(recorded: Date, startDate?: Date, timeDifferenceDisplayFormat?: TimeDifferenceDisplayFormat): any {
    
    var actualRecorded = new Date(recorded);
    var actualStartDate = new Date(startDate);

    switch(timeDifferenceDisplayFormat) {
      case TimeDifferenceDisplayFormat.Days:
        return `${this.convertToDays(actualRecorded, actualStartDate)} day(s)`;
      case TimeDifferenceDisplayFormat.Weeks:
        return `${this.convertToWeeks(actualRecorded, actualStartDate)} week(s)`;
      case TimeDifferenceDisplayFormat.Months:
          return `${this.convertToMonths(actualRecorded, actualStartDate)} month(s)`;
      default:
        return recorded;
    }
  }

  convertToDays(recorded: Date, startDate?: Date) {
    var startDate = new Date(startDate);
    var endDate = new Date(recorded);

    var diff = Math.abs(endDate.getTime() - startDate.getTime());
    return Math.ceil(diff / (1000 * 3600 * 24));
  }

  convertToWeeks(recorded: Date, startDate?: Date) {
    var days = this.convertToDays(recorded, startDate);

    return (days / 7).toFixed(0);
  }

  convertToMonths(recorded: Date, startDate?: Date) {
    return (recorded.getFullYear() - startDate.getFullYear()) * 12 + (recorded.getMonth() + 1) - (startDate.getMonth() + 1) + (recorded.getDay() >= startDate.getDay() ? 0 : -1);
  }
}
