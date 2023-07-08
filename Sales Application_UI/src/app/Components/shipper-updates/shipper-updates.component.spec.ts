import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShipperUpdatesComponent } from './shipper-updates.component';

describe('ShipperUpdatesComponent', () => {
  let component: ShipperUpdatesComponent;
  let fixture: ComponentFixture<ShipperUpdatesComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ShipperUpdatesComponent]
    });
    fixture = TestBed.createComponent(ShipperUpdatesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
