import Vue from "vue";
import moment from "moment";
import App from './App.vue'

App.directive("formatdate", function (value) {
    if (value) {
        return moment(String(value)).format("MM/DD/YYYY hh:mm");
    }
});