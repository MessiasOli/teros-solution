export function SetPageSelected(id:string){
    if(!id) return
    document.querySelectorAll(`.selectable`).forEach(c => c.classList.remove("active"))
    let el = document.querySelector(`#${id}`);
    if(el)
      el.classList.add("active")
}