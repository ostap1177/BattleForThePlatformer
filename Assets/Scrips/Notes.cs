/*
 * + 1._animator = GetComponent<Animator>(); 
 * При использовании GetComponent нужно убедиться, 
 * что есть атрибут RequireComponent. 
 * Ссылка на рекомендацию: https://agava.notion.site/RequireComponent-22b7c385c77546f682a0d8c3cf9998ac 
 * 
 * 2. [SerializeField] private GameObject _coin; 
 * В текущем варианте можно передать вообще любой объект, 
 * а передача конкретного типа гарантирует правильность создаваемого объекта, 
 * напрямую говорит, какой тип нужно передать в инспекторе и 
 * упрощает выбор из множества префабов, каждый из которых является GameObject.
 * Instantiate может принимать и возвращать нужный компонент вместо GameObject. 
 * Подробнее об этом здесь: https://agava.notion.site/cb2f8b5609d64fefb13e4fe69e4c1b88 
 * 
 * + 3. Заместо такого странного private IEnumerator Destroyed() дестроя, 
 * можно просто при создании монетки вызвать её дестрой с задержкой по времени 
 * (второй параметр в методе дестрой)
 */

/* Продолжаем работать над платформером, реализуем работу со здоровьем персонажа. 
 * Теперь враги и игрок могут атаковать друг друга, когда подходят близко. 
 * Враги должны начать преследовать игрока, когда увидят его, в обратном случае они должны патрулировать территорию. 
 * А игрок может лечиться, подбирая аптечки, которые случайным образом разбросаны по уровню.
 * 
 * Отображать здоровье в этой задаче не требуется, это мы сделаем в следующей задаче.*/