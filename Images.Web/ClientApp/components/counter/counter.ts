import Vue from 'vue';
import { Component } from 'vue-property-decorator';

@Component
export default class CounterComponent extends Vue {
    currentCount: number = 0;

    incrementCounter() {
        this.currentCount++;
    }
}
