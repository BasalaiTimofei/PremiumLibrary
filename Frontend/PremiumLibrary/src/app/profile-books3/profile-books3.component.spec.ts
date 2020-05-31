import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProfileBooks3Component } from './profile-books3.component';

describe('ProfileBooks3Component', () => {
  let component: ProfileBooks3Component;
  let fixture: ComponentFixture<ProfileBooks3Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProfileBooks3Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProfileBooks3Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
