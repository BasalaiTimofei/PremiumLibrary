import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProfileBooks4Component } from './profile-books4.component';

describe('ProfileBooks4Component', () => {
  let component: ProfileBooks4Component;
  let fixture: ComponentFixture<ProfileBooks4Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProfileBooks4Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProfileBooks4Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
