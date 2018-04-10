# third3DHomework

### 1. 操作与总结
* 参考 Fantasy Skybox FREE 构建自己的游戏场景<br>
天空盒的创建：<br>
首先在Asset菜单中选择create->Material，将shader勾选为skybox，然后选择Cubemap，也就是<br>
创建一个立方体型的天空盒，接着在Asset的搜索栏里搜索Skybox，选择Asset Store，然后打开，<br>
就可以在Asset Store下载自己想要的天空盒资源，然后将其拖入天空盒的材质里，最后创建的天空盒<br>
拖入场景里就可以制作出一个十分精美的天空盒了。<br>
![](https://github.com/flashowner/third3DHomework/blob/master/%E6%88%AA%E5%9B%BE/%E6%8D%95%E8%8E%B71.PNG) <br>
其次是创建地形，Unity提供了简单的地形设计工具，点击GameObject->3d object->Terrain就<br>
可以创建一个3D的地形了。然后在工具箱里选择地形设计工具，改变Brush Size可以改变笔刷的大小，<br>
利用造山工具可以刷出自己想要的地形，但是由于Unity5不提供树和草的资源，所以需要自己从资源商城里<br>
下载，然后添加到笔刷里。此外还可以在设置里给地形添加贴图作为材质。完成后的地形如图所示：<br>
![](https://github.com/flashowner/third3DHomework/blob/master/%E6%88%AA%E5%9B%BE/%E6%8D%95%E8%8E%B7.PNG) <br>
这是完整的场景图：<br>
![](https://github.com/flashowner/third3DHomework/blob/master/%E6%88%AA%E5%9B%BE/%E6%8D%95%E8%8E%B72.PNG) <br>
* 写一个简单的总结，总结游戏对象的使用<br>
对于每一个游戏对象而言，transform是最为基本的属性，它决定了游戏对象的相对坐标，此外每一个游戏<br>
对象还有材质，颜色的渲染等基本的属性。而游戏对象又是由各种不同的组件组成，组件式的构成大大增加<br>
了游戏对象的灵活性，使得游戏对象在创建后并不是固定不变的，如果想要添加别的属性，如声音，可以<br>
直接添加相关的部件，部件会赋予游戏对象相应的属性。可以说整个游戏都是由各种不同的游戏对象组成<br>
的，小到灯光，照相机，大到地形天空盒都是一个游戏对象。而且unity可以通过拖拽的方式给游戏对象<br>
添加部件和材料，这又使得游戏的灵活性增加和游戏开发的时间减少。
### 2. 编程实践
* 牧师与魔鬼 动作分离版
由于上次做的牧师与魔鬼主要是用过GUI界面完成各种动作的，所以才拆分动作的时候就不如用鼠标点击那么好拆分<br>
这次游戏的UML图如图所示：<br>
![](https://github.com/flashowner/third3DHomework/blob/master/%E6%88%AA%E5%9B%BE/%E6%8D%95%E8%8E%B73.PNG)
我从FirstController中提取出了上船动作CCGetOnTheBoat下船动作CCGetOffTheBoat和船的移动动作CCRunBoat<br>
使得FirstController不用去考虑动作是如何实现的，部分代码如下所示：<br>
CCGetOnTheBoat:<br>
![](https://github.com/flashowner/third3DHomework/blob/master/%E6%88%AA%E5%9B%BE/%E6%8D%95%E8%8E%B74.PNG)
CCGetOffTheBoat:<br>
