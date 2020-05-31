import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CatalogAuthorsComponent } from './catalog-authors.component';

describe('CatalogAuthorsComponent', () => {
  let component: CatalogAuthorsComponent;
  let fixture: ComponentFixture<CatalogAuthorsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CatalogAuthorsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CatalogAuthorsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
