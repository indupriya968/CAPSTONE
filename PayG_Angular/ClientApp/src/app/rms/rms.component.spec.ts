import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RMSComponent } from './rms.component';

describe('RMSComponent', () => {
  let component: RMSComponent;
  let fixture: ComponentFixture<RMSComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RMSComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RMSComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
