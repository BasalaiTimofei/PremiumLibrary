import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProfileBooks5Component } from './profile-books5.component';

describe('ProfileBooks5Component', () => {
  let component: ProfileBooks5Component;
  let fixture: ComponentFixture<ProfileBooks5Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProfileBooks5Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProfileBooks5Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
