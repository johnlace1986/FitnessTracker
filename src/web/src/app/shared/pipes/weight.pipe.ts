import { Pipe, PipeTransform } from '@angular/core';
import { WeightDisplayFormat } from 'src/app/models/weight-display-format';

@Pipe({
  name: 'weight'
})
export class WeightPipe implements PipeTransform {
  private poundsPerStone: number = 14;
  private poundsPerKilogram: number = 2.20462;

  transform(value: number, displayFormat?: WeightDisplayFormat): any {

    switch(displayFormat) {
      case WeightDisplayFormat.Pounds:
        return `${value} lbs`;
        case WeightDisplayFormat.Stones:
          return this.convertToStones(value);
          case WeightDisplayFormat.StonesFraction:
            return this.convertToStonesFraction(value);
            case WeightDisplayFormat.Kilograms:
              return this.convertToKilograms(value);
      default:
        return value;
    }
  }

  convertToStones(pounds: number) {
    let stones: number = 0;
    let remainingPounds: number = pounds;

    while (remainingPounds >= this.poundsPerStone) {
      stones++;
      remainingPounds -= this.poundsPerStone;
    }

    return `${stones} st ${remainingPounds.toFixed(1)} lbs`;
  }

  convertToStonesFraction(pounds: number) {
    let fraction: number = pounds / this.poundsPerStone;
    return `${fraction.toFixed(2)} st`;
  }

  convertToKilograms(pounds: number) {
    let kilograms: number = pounds / this.poundsPerKilogram;
    return `${kilograms.toFixed(2)} kg`;
  }
}
