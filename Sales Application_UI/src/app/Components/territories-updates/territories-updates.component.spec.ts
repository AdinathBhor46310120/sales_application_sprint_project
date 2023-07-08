import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TerritoriesUpdatesComponent } from './territories-updates.component';

describe('TerritoriesUpdatesComponent', () => {
  let component: TerritoriesUpdatesComponent;
  let fixture: ComponentFixture<TerritoriesUpdatesComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TerritoriesUpdatesComponent]
    });
    fixture = TestBed.createComponent(TerritoriesUpdatesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
