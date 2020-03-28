# Transcode Tools

GUI to remux and transcode videos based on the teachings and tools of [Don Melton](http://donmelton.com/)

## About

I hate having to do things in multiple tools and/or from the command line. That's just how I grew up, GUI all the way. So after spending
some time transcoding my own videos using both Don's [transcode-video](https://github.com/donmelton/video_transcoding) and [other-transcode](https://github.com/donmelton/other_video_transcoding), and other tools such as [FFmpeg](http://ffmpeg.org/),
MKVToolnix, etc. I decided I wanted to roll my workflow into a one-stop shop. 

I'm not re-inventing the wheel, just taking tools that perform functions very well and putting a graphical face on them, so that to me,
they are easier to use and batch friendly at the same time.

## Installation

The application is portable so really the installation for it is simple. 
The applications depends on the following:
  ### For Primary functions
  [FFmpeg](http://ffmpeg.org/)
  
  [ffprobe](http://ffmpeg.org/)
  
  [other-transcode](https://github.com/donmelton/other_video_transcoding)
  
  ### For ancillary functions
  mpv
  
  subtitleedit

All of these should be made available through the system Path

## Usage
The design is simple. It expects that you have already ripped your movies and named them properly (based on Plex naming standards). Once you launch the program it defaults to Remux mode. If you already have your files ready for the transcode process you can switch modes and start making settings for transcoding.

### Remuxing
Choose your input directory. The program is expecting you to select a folder that has the folders of the movies you wish to process.
Choose your output directory, This will be used when creating the settings files. The preferred would be an empty directory but you can use a directory with movies already in it if you wish.

Select a movie from the left hand pane. This will populate the right hand pane with a tree view of the items in the folder organizied by file type, featurette, deleted scenes, interviews, etc.

Selecting a title from the right hand pane will populate the tables in the lower half of the screen. For video this is really just informational and you need do nothing with it. In the audio section you can rearrainge the titles in the order you wish them to be (if they need to be changed) and then select the tracks that you want included in the remuxed file. Subtitles function the same as audio, re-order them if you need to select the ones you want in the remuxed file. 

The checkboxes for default (audio and subtitle) and forced (subtitle only) are checked based on the input file. you can change these as you wish to have the final product set-up the way you would like.

If your not sure what the audio tracks are or if the subtitle tracks are full or just extra bits. you can view the title in either MPV or SubTitleEdit as needed. Or if you run across a mis-named title you can go directly to the folder to fix it.

Once you have the title set the way you want select Save Remux Settings. This creates a folder called Remux in the input directory. That folder will have a folder for each movie with a text file for each title you create settings for. The title will also turn green in the upper right hand window to identify that you have created a settings file for it.

You do not have to create a settings file for every title. If a title is fine as it is leave it alone and the application will simply copy the files to the output folder. 

If you at a later point reopen this particular input folder all the previously created setting will show in the titles in the green color and selecting them will show the setting that you choose as compared to the file in its untouched state.

When you are ready go to the file menu and select Run Remux. This will bring up a new window with the input folder you have been working with. select the titles you wish to remux or right click in the window and select all. Then click Start Remux, the right hand pane of this window will give you a running view of the action taking place. when complete the program will print "Job Completed" in the window (NOTE: sometimes this isn't the last line in the window, I'm still working on that)

## Transcode
Choose your input directory. The program is expecting you to select a folder that has the folders of the movies you wish to process.
Choose your output directory, This will be used when creating the settings files. The preferred would be an empty directory but you can use a directory with movies already in it if you wish.

Select a movie from the left hand pane. This will populate the right hand pane with a tree view of the items in the folder organizied by file type, featurette, deleted scenes, interviews, etc.

Selecting a title from the right hand pane will populate the tables in the lower half of the screen. For the video select the output format that you wish to use. Since the underlying application is other-transcode the only options are h264 or hevc. The options for changing the frame rate and resolution are there but currently non-functional.

All Audio and Subtitle tracks will be added to the transcoded file. This is because it is expected in the remuxing stage you have selected only the tracks you wish to keep. 

Since this tool is a wrapper for other-transcode you should understand the defaults that it uses when selecting settings for audio here. 90%+ of the time you can set Format, Width, and Bit Rate to Keep and the track will just be copied. Again, please be sure you understand the defaults used by other-transcode. 

For Audio tracks that are in a lossless format you can pass them through but that really defeats the purpose set out with other-transcode. Based on the recommendations of the Hive-Mind of other-transcode lossless tracks should be the tracks you keep when remuxing and then converted to eac3(DD+) when transcoding this should give you the best results and the closest to the original. 

Dealing with subtitle tracks is really simple, the application adds them all the only option you need to be concerned with is if you want to burn the subtitles into the image or not. My preference is to burn forced subtitles into the video, but there are other that don't tink that is needed. It is really up to how you want to titles to behave.

When you have gotten the title set the way you want it click the Save Transcode Settings button. As with Remux this will create a folder in the input directory named Transcode with movie folders inside of it and txt files of the settings you created. Also you do not have to create settings for all files. The program processes files with no settings using the basic defaults of other-transcode, with the exception that all audio and subtitle tracks are included.
