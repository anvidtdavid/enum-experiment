import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EnumDemoComponent } from './enum-demo.component';

describe('EnumDemoComponent', () => {
  let component: EnumDemoComponent;
  let fixture: ComponentFixture<EnumDemoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EnumDemoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EnumDemoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
