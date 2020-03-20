import Vue from 'vue'
import Services from '@/utils/services';

Vue.directive('source', {
    bind: function (el, binding, vnode) {
        if (el.dataset.objectURL) {
            URL.revokeObjectURL(el.dataset.objectURL);
        }
        Services.get(binding.value, null, true, { dataType: 'arraybuffer' }).done(function (data, textStatus, jqXHR) {
            var blob = new Blob(
                [data],
                { type: jqXHR.getResponseHeader('content-type') }
            );

            el.dataset.objectURL = URL.createObjectURL(blob);
            el.setAttribute('src', el.dataset.objectURL);
        });
    },
    unbind: function (el, binding, vnode) {
        if (el.dataset.objectURL) {
            URL.revokeObjectURL(el.dataset.objectURL);
        }
    },
})
