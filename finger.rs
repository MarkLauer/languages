fn main() {
    let a1 = Point { x: 0.0, y: 0.0 };
    let b1 = Point { x: 4.0, y: 4.0 };
    let a2 = Point { x: -5.0, y: -1.0 };
    let b2 = Point { x: -4.0, y: -2.0 };
    let halfline = Line { a: a1, b: b1 };
    let segment = Line { a: a2, b: b2 };
    let (ints, x, y) = intersects(&halfline, &segment);    
    if ints {
        let schl = (halfline.b.x - halfline.a.x) * (x - halfline.a.x) + (halfline.b.y - halfline.a.y) * (y - halfline.a.y);
        let scsg = (segment.a.x - x) * (segment.b.x - x) + (segment.a.y - y) * (segment.b.y - y);
        if scsg <= 0.0 {
            if schl >= 0.0 {
                println!("{},{} {},{}", segment.a.x, segment.a.y, segment.b.x, segment.b.y);
            } else {
                println!("niet");
            }
        } else {
            println!("niet");
        }
    } else {
        println!("niet");
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

fn intersects(l1: &Line, l2: &Line) -> (bool, f64, f64) {
    let eps = 1e-9;
    let (x1, y1, x2, y2, x3, y3, x4, y4) = (l1.a.x, l1.a.y, l1.b.x, l1.b.y, l2.a.x, l2.a.y, l2.b.x, l2.b.y);
    let den = (x1 - x2) * (y3 - y4) - (y1 - y2) * (x3 - x4);
    if den.abs() < eps {
        return (false, 0.0, 0.0);
    } else {
        let px = ((x1 * y2 - y1 * x2) * (x3 - x4) - (x1 - x2) * (x3 * y4 - y3 * x4)) / den;
        let py = ((x1 * y2 - y1 * x2) * (y3 - y4) - (y1 - y2) * (x3 * y4 - y3 * x4)) / den;
        return (true, px, py);
    }
}
