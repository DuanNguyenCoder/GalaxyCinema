import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DragableComponent } from './dragable.component';

describe('DragableComponent', () => {
  let component: DragableComponent;
  let fixture: ComponentFixture<DragableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DragableComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DragableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
