import { trigger, state, style, transition, animate } from '@angular/animations';

export const tutorialAnimation = trigger('openClose', [
  // ...
  state(
    'open',
    style({
      height: '300px'
      // opacity: 1,
      // backgroundColor: 'yellow'
    })
  ),
  state(
    'closed',
    style({
      height: '100px'
      // opacity: 0.5,
      // backgroundColor: 'green'
    })
  ),
  transition('open => closed', [animate('4s')]),
  transition('closed => open', [animate('4s')])
]);
