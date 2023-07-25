

$(function () {
  'use strict'

 
  var salesChartCanvas = $('#salesChart').get(0).getContext('2d')

  var salesChartData = {
      labels: ModelData.recapModel.month,
    datasets: [
      {
        label: 'Digital Goods',
        backgroundColor: 'rgba(60,141,188,0.9)',
        borderColor: 'rgba(60,141,188,0.8)',
        pointRadius: false,
        pointColor: '#3b8bba',
        pointStrokeColor: 'rgba(60,141,188,1)',
        pointHighlightFill: '#fff',
        pointHighlightStroke: 'rgba(60,141,188,1)',
            data: ModelData.recapModel.salesData1
      },
      {
        label: 'Electronics',
        backgroundColor: 'rgba(210, 214, 222, 1)',
        borderColor: 'rgba(210, 214, 222, 1)',
        pointRadius: false,
        pointColor: 'rgba(210, 214, 222, 1)',
        pointStrokeColor: '#c1c7d1',
        pointHighlightFill: '#fff',
        pointHighlightStroke: 'rgba(220,220,220,1)',
          data: ModelData.recapModel.salesData2
      }
    ]
  }

  var salesChartOptions = {
    maintainAspectRatio: false,
    responsive: true,
    legend: {
      display: false
    },
    scales: {
      xAxes: [{
        gridLines: {
          display: false
        }
      }],
      yAxes: [{
        gridLines: {
          display: false
        }
      }]
    }
  }

 
  var salesChart = new Chart(salesChartCanvas, {
    type: 'line',
    data: salesChartData,
    options: salesChartOptions
  }
  )

  
  var pieChartCanvas = $('#pieChart').get(0).getContext('2d')
  var pieData = {
      labels: ModelData.usage.browserName,
    datasets: [
      {
            data: ModelData.usage.data,
        backgroundColor: ['#f56954', '#00a65a', '#f39c12', '#00c0ef', '#3c8dbc', '#d2d6de']
      }
    ]
  }
  var pieOptions = {
    legend: {
      display: false
    }
  }
  
  var pieChart = new Chart(pieChartCanvas, {
    type: 'doughnut',
    data: pieData,
    options: pieOptions
  })

  
   
  $('#world-map-markers').mapael({
    map: {
      name: 'usa_states',
      zoom: {
        enabled: true,
        maxLevel: 10
      }
    }
  })

})


