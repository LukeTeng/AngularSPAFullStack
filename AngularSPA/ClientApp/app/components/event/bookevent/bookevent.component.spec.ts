/// <reference path="../../../../../node_modules/@types/jasmine/index.d.ts" />
import { assert } from 'chai';
import { BookEventComponent } from './bookevent.component';
import { TestBed, async, ComponentFixture } from '@angular/core/testing';

let fixture: ComponentFixture<BookEventComponent>;

describe('Counter component', () => {
    beforeEach(() => {
        TestBed.configureTestingModule({ declarations: [BookEventComponent] });
        fixture = TestBed.createComponent(BookEventComponent);
        fixture.detectChanges();
    });

    it('should display a title', async(() => {
        const titleText = fixture.nativeElement.querySelector('h1').textContent;
        expect(titleText).toEqual('Counter');
    }));

    it('should start with count 0, then increments by 1 when clicked', async(() => {
        const countElement = fixture.nativeElement.querySelector('strong');
        expect(countElement.textContent).toEqual('0');

        const incrementButton = fixture.nativeElement.querySelector('button');
        incrementButton.click();
        fixture.detectChanges();
        expect(countElement.textContent).toEqual('1');
    }));
});
