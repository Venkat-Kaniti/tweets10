exports = module.exports = {
	entry: [
		'./index.js'
	],
	output: {
		filename: 'bundle.js',
		path: './dist'
	},
	module: {
		loaders: [
			{
				test: /\.jsx?$/,
				exclude: /node_modules/,
				loader: 'babel',
				query: {
					presets: [
						'airbnb'
					]
				}
			},
			{
				test: /\.css$/,
				exclude: /node_modules/,
				loader: 'style!css'
			}
		]
	}
};