Tiny Lab Productions Library
============================

This is library which we, [Tiny Lab Productions](www.tinylabproductions.com) use
in our Unity3D games. 

It contains various things, including but not limited to:

* Android utilities.
* BiMap.
* Promises & Futures, CoRoutine helpers.
* Various data structures.
* A bunch of extension methods.
* JSON parser/emmiter.
* Functional utilities: Option, Lazy, Tuple, Unit, co-variant functions and actions, rudimentary pattern matching.
* Reactive extensions: observables, reactive references, lists and list views.
* Tween utilities: mainly to make tweens type-safe.
* Various other misc utilities.

Disclaimer
----------

You are free to use this for your own games. Patches and improvements are welcome. A mention in your game credits would be nice.

If you are considering using this it would be also nice if you contacted me (Artūras Šlajus, arturas@tinylabproductions.com) so we could create a community around this.

Using in your project
---------------------

There are various ways this library can be used in your project, but I suggest 
using a git subtree and symlinking the required code into your assets folder.

In general it goes like this:

* cd your_project_dir

Add remote repository reference:

* git remote add -f tlplib git@github.com:tinylabproductions/tlplib.git

Merge the subtree:

* git subtree add -P vendor\tlplib --squash tlplib master

Link the code into your assets:

* mkdir Assets\Vendor

On Windows:

* mklink /j Assets\Vendor\TLPLib vendor\tlplib\Code\TLPLib\

On Mac OS X / Linux:

* ln -s ../../vendor/tlplib/Code/TLPLib Assets/Vendor/TLPLib

And you should be good to go.

Don't forget that when you clone your git repository to a new place, your 
```tlplib``` remote will be lost so you will need to readd it.

### Defining compiler constants ###

There are bits of code that depend on third party libraries that you might not
want to use in your project. They are disabled by default via precompiler 
defines.

If you wish to use them, you need to define the constants in Unity3D (Menu Bar > Edit > Project Settings > Player > (your platform) > Other Settings > Scripting Define Symbols).

* GOTWEEN - if you are using [GoKit](https://github.com/prime31/GoKit).
* DFGUI - if you are using [Daikon Forge GUI](http://www.daikonforge.com/dfgui/). Beware that this also uses GOTWEEN as well.

Getting latest updates
----------------------

Is as simple as:

* git subtree pull -P vendor/tlplib tlplib master

Submitting your changes
-----------------------

Fork this repository on github and add it as a remote, e.g.:

* git remote add tlplib_my git@github.com:thisisme/tlplib.git

Commit your updates to your repository and push them to forked repo:

* git subtree push -P vendor/tlplib tlplib_my

And finally send me a pull request :)

Questions and feedback
----------------------

Contact me at <arturas@tinylabproductions.com>.
