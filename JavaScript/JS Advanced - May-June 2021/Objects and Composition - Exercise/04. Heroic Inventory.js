function register(heroes) {
    let register = [];
    for (const h of heroes) {
        let [name, level, items] = h.split(' / ');
        level = Number(level);
        items = items ? items.split(', ') : [];
        register.push({ name, level, items });
    }
    console.log(JSON.stringify(register));
}
register(['Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara']
);