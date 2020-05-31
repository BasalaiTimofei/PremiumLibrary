import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProfileBooks2Component } from './profile-books2.component';

describe('ProfileBooks2Component', () => {
  let component: ProfileBooks2Component;
  let fixture: ComponentFixture<ProfileBooks2Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProfileBooks2Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProfileBooks2Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
