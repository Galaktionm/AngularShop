import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BookwishlistComponent } from './bookwishlist.component';

describe('BookwishlistComponent', () => {
  let component: BookwishlistComponent;
  let fixture: ComponentFixture<BookwishlistComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BookwishlistComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BookwishlistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
