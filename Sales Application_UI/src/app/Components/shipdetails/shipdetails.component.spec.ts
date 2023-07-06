import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShipdetailsComponent } from './shipdetails.component';

describe('ShipdetailsComponent', () => {
  let component: ShipdetailsComponent;
  let fixture: ComponentFixture<ShipdetailsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ShipdetailsComponent]
    });
    fixture = TestBed.createComponent(ShipdetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
