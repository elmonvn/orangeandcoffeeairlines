import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShareFlightComponent } from './share-flight.component';

describe('ShareFlightComponent', () => {
  let component: ShareFlightComponent;
  let fixture: ComponentFixture<ShareFlightComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShareFlightComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShareFlightComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
