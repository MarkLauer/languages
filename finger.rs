fn main() {
    let a1 = Point { x: 0.0, y: 0.0 };
    let b1 = Point { x: 4.0, y: 4.0 };
    let a2 = Point { x: 2.0, y: 0.0 };
    let b2 = Point { x: 0.0, y: 2.0 };
    let halfline = Line { a: a1, b: b1 };
    let segment = Line { a: a2, b: b2 };
    let (intersects, x, y) = intrsctn(&halfline, &segment); //(x,y) - точка пересечения прямых
    if intersects {
        let schl = (halfline.b.x - halfline.a.x) * (x - halfline.a.x) +
                   (halfline.b.y - halfline.a.y) * (y - halfline.a.y); //скалярное произведение векторов ab и a(x,y)
        let scsg = (segment.a.x - x) * (segment.b.x - x) + (segment.a.y - y) * (segment.b.y - y);
        if scsg <= 0.0 { //проверка на принадлежность точки пересечения отрезку
            if schl >= 0.0 { //проверка на принадлежность точки пересечения полупрямой
                println!("{},{} {},{}",
                         segment.a.x,
                         segment.a.y,
                         segment.b.x,
                         segment.b.y);
            } else {
                println!("\n");
            }
        } else {
            println!("\n");
        }
    } else {
        println!("\n");
    }
}

struct Point {
    x: f64,
    y: f64,
}

struct Line {
    a: Point,
    b: Point,
}

fn intrsctn(l1: &Line, l2: &Line) -> (bool, f64, f64) {
    let eps = 1e-9;
    let (x1, y1, x2, y2, x3, y3, x4, y4) =
        (l1.a.x, l1.a.y, l1.b.x, l1.b.y, l2.a.x, l2.a.y, l2.b.x, l2.b.y);
    let den = (x1 - x2) * (y3 - y4) - (y1 - y2) * (x3 - x4); //знаменатель для нахождения точки пересечения
    if den.abs() < eps { //проверка на параллельность/совпадение прямых
        return (false, 0.0, 0.0);
    } else {
        let px = ((x1 * y2 - y1 * x2) * (x3 - x4) - (x1 - x2) * (x3 * y4 - y3 * x4)) / den;
        let py = ((x1 * y2 - y1 * x2) * (y3 - y4) - (y1 - y2) * (x3 * y4 - y3 * x4)) / den;
        return (true, px, py);
    }
}

fn dist(a: &Point, b: &Point) -> f64 { //функция расчета расстояния между точками
    ((a.x - b.x) * (a.x - b.x) + (a.y - b.y) * (a.y - b.y)).sqrt()
}
