# CpsDemo

This is a demonstration of Continuation Passing Style (CPS).

Here is what my friend André van Meulebrouck has to say about CPS:

"As to CPS: I’d be very surprised if CPS is ever faster.  My guess: it should always be slower.

Why use CPS?

One reason is when writing a compiler where things can go wrong at any step; hence you want very explicit control, and you want to see what’s going on more directly.

Another is when you don’t have linear recursion (i.e., you have tree recursion), hence can’t refactor non-tail recursive code into tail recursive code (using the accumulator trick).

Generally tail recursion is faster (despite the need for reversing the accumulated result); but the bigger concern is generally not blowing out the stack.

In the case of tree recursion, you can refactor to CPS; in which case you’re trading stack for heap (hence you can’t blow out the stack, but you can blow out the heap; but heap is more plentiful).

In CPS, you’re basically merely making the future of the computation explicit.  The future of a computation is normally implicit; by making it explicit you can manipulate it in interesting ways.  You then pass around the future explicitly and run a function on it.  That’s why the id function becomes so important:  if you want to continue towards the future (as things are going) you use id as your what-to-do-next function.  If you want to abort (or swap out the future for an alternative future), you use a function that consumes the future and ignores it (instead returning some alternative future).

Generally, when doing CPS you write in the customary way first, then refactor to make the future more explicit by passing it.  Generally (by tradition) in any function that consumes a future (a.k.a. continuation), the argument is named k (not sure why:  I wonder if it’s because continuation starts with a k in German?!?).

CPS got started in Scheme (MIT’s dialect of LISP) and I found it much easier to understand all this in Scheme first before seeing it in F# and Haskell."

# Articles relating to Continuation Passing Style

https://fsharpforfunandprofit.com/posts/computation-expressions-continuations/

http://www.markhneedham.com/blog/2009/06/22/f-continuation-passing-style/

http://www.nutsaboutcoding.com/?p=513

https://lorgonblog.wordpress.com/2008/06/07/catamorphisms-part-seven/
