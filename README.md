1. Сглаживание поворота: \n
   `ChangesHorizontalRotateSystem/ChangesVerticalRotateSystem` - применение изменений с сервера для поворота по Y
   `LerpHorizontalRotateSystem/LerpVerticalRotateSystem` - плавное изменение поворота (`_filter.Get1(i).Speed` задается из инспектора)
2. Приседание \n
   `ChangesCrouchSystem` - применение изменений с сервера для приседания
   `KeyCrouchSystem` - проверка на нажатую кнопку `Ctrl`
   `CrouchSystem` - само приседание. Объекты головы и тела помещены в родительский объект в префабе. При приседании изменяется положение этого объекта (`CrouchRoot`) на заданную величину (`CrouchPosY`) в инспекторе по Y
