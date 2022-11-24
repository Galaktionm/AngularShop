import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddBookWishListComponent } from './add-book-wish-list.component';

describe('AddBookWishListComponent', () => {
  let component: AddBookWishListComponent;
  let fixture: ComponentFixture<AddBookWishListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddBookWishListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddBookWishListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
