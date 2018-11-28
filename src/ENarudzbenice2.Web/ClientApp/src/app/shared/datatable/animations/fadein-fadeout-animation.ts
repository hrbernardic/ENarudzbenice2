import { trigger, sequence, state, animate, transition, style } from '@angular/animations';

export const fadeInFadeOutAnimation = trigger('fadeInFadeOutAnimation', [
  state(
    'in',
    style({
      opacity: 1
    })
  ),
  state(
    'out',
    style({
      opacity: 0
    })
  ),
  transition('in <=> out', [animate('.38s ease')])
]);
