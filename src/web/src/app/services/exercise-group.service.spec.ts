import { TestBed } from '@angular/core/testing';

import { ExerciseGroupService } from './exercise-group.service';

describe('ExerciseGroupService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ExerciseGroupService = TestBed.get(ExerciseGroupService);
    expect(service).toBeTruthy();
  });
});
