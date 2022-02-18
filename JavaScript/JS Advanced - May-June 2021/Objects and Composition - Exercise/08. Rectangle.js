function rectangle(w, h, color) {
    let rectangle = {
        width: w,
        height: h,
        color: color[0].toUpperCase() + color.substring(1),
        calcArea: function() {return this.width* this.height;}
    }
    return rectangle;
}
let rect = rectangle(4, 5, 'red');
console.log(rect.width);
console.log(rect.height);
console.log(rect.color);
console.log(rect.calcArea());
