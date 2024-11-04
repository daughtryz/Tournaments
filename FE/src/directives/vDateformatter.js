export const vDateformatter = {
    mounted: (el, binding) => {
        let convertedDate = new Date(binding.value);
        el.innerHTML = el.innerHTML + ' ' + convertedDate.toDateString();
    }
}