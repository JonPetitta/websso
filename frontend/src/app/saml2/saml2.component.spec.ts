import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { Saml2Component } from './saml2.component';

describe('Saml2Component', () => {
  let component: Saml2Component;
  let fixture: ComponentFixture<Saml2Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ Saml2Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(Saml2Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
