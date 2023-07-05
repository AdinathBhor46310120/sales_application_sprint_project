import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShipperRegisterComponent } from './shipper-register.component';

describe('AuthorRegisterComponent', () => {
  let component: ShipperRegisterComponent;
  let fixture: ComponentFixture<ShipperRegisterComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ShipperRegisterComponent]
    });
    fixture = TestBed.createComponent(ShipperRegisterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
