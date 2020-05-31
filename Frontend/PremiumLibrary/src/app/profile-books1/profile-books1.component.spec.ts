import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProfileBooks1Component } from './profile-books1.component';

describe('ProfileBooks1Component', () => {
  let component: ProfileBooks1Component;
  let fixture: ComponentFixture<ProfileBooks1Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProfileBooks1Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProfileBooks1Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
