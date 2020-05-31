import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CatalogGenresComponent } from './catalog-genres.component';

describe('CatalogGenresComponent', () => {
  let component: CatalogGenresComponent;
  let fixture: ComponentFixture<CatalogGenresComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CatalogGenresComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CatalogGenresComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
